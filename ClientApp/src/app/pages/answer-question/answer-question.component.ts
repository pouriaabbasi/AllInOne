import { Component, OnInit, Input } from '@angular/core';
import { QuestionQueModel, QuestionModel, ProcessQuestionModel } from 'src/app/models/leitner.model';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { LeitnerService } from 'src/app/services/leitner.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Observable, forkJoin } from 'rxjs';

@Component({
  selector: 'app-answer-question',
  templateUrl: './answer-question.component.html',
  styleUrls: ['./answer-question.component.css']
})
export class AnswerQuestionComponent extends BaseComponent implements OnInit {

  @Input()
  boxId: number;
  questionQues: QuestionQueModel[] = [];
  currentStage: QuestionQueModel;
  currentQuestion: QuestionModel = new QuestionModel();
  answerdQuestions: ProcessQuestionModel[] = [];
  currentStageIndex = 0;
  currentQuestionIndex = 0;
  totalQuestions = 0;
  totalCurrentIndex = 0;
  isFinished = false;
  isFace = true;
  successCount = 0;
  successPercentage = 0;
  failCount = 0;
  failPercentage = 0;

  constructor(
    protected toastr: ToastrService,
    private leitnerService: LeitnerService,
    private activeModal: NgbActiveModal
  ) {
    super(toastr);
  }

  ngOnInit() {
    this.fetchQuestionQue();
  }

  private fetchQuestionQue() {
    this.leitnerService.getQuestionQue(this.boxId)
      .subscribe(result => {
        if (result) {
          this.questionQues = result;
          result.forEach(x => {
            this.totalQuestions += x.questions.length;
          });
          this.getNextQuestion();
          super.showInfo('Ready', 'Your questions are ready, Good Luck!');
        }
      });
  }

  private getNextQuestion() {
    if (this.hasQuestion()) {
      this.currentQuestion = this.currentStage.questions[this.currentQuestionIndex++];
      this.totalCurrentIndex++;
    } else if (this.hasStage()) {
      this.getNextStage();
      this.getNextQuestion();
    } else {
      this.setFinish();
    }
  }

  private setFinish() {
    this.isFinished = true;
    this.isFace = true;
    this.currentQuestion.vocabulary = 'Your Test Is Finished ;)';
  }

  private getNextStage() {
    this.currentStage = this.questionQues[this.currentStageIndex++];
    this.currentQuestionIndex = 0;
  }

  private hasQuestion(): boolean {
    if (!this.currentStage) {
      this.getNextStage();
    }
    return !(this.currentQuestionIndex === this.currentStage.questions.length);
  }

  private hasStage() {
    return !(this.currentStageIndex === this.questionQues.length);
  }

  public cancel() {
    this.activeModal.close(false);
  }

  public changeFace() {
    if (!this.isFinished) {
      this.isFace = !this.isFace;
    }
  }

  public success() {
    const timeout = this.isFace ? 0 : 1000;
    this.isFace = true;
    this.successCount++;
    this.successPercentage = (100 * this.successCount) / this.totalQuestions;
    setTimeout(() => {
      this.answerdQuestions.push({
        id: this.currentQuestion.id,
        isSuccess: true
      });
      this.getNextQuestion();
    }, timeout);
  }

  public fail() {
    const timeout = this.isFace ? 0 : 1000;
    this.isFace = true;
    this.failCount++;
    this.failPercentage = (100 * this.failCount) / this.totalQuestions;
    setTimeout(() => {
      this.answerdQuestions.push({
        id: this.currentQuestion.id,
        isSuccess: false
      });
      this.getNextQuestion();
    }, timeout);
  }

  public submit() {
    const observables = [];
    this.answerdQuestions.forEach(question => {
      observables.push(this.leitnerService.processQuestion(question));
    });
    forkJoin(observables)
      .subscribe(x => {
        super.showSuccess('Submit Test Result', 'Your test result submited successfuly');
        this.activeModal.close(true);
      });
  }
}
