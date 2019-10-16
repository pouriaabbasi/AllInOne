import { Component, OnInit, Input } from '@angular/core';
import { AddQuestionModel } from 'src/app/models/leitner.model';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { LeitnerService } from 'src/app/services/leitner.service';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent extends BaseComponent implements OnInit {

  @Input()
  boxId: number;
  model: AddQuestionModel = new AddQuestionModel();

  constructor(
    protected toastr: ToastrService,
    private activeModal: NgbActiveModal,
    private leitnerService: LeitnerService
  ) {
    super(toastr);
  }

  ngOnInit() {
  }

  public cancel() {
    this.activeModal.close(false);
  }

  public addQuestion() {
    this.model.boxId = this.boxId;
    this.leitnerService.addQuestion(this.model)
      .subscribe(result => {
        if (result) {
          super.showSuccess('Add Question', 'Question add successfuly');
          this.activeModal.close(true);
        }
      });
  }
}
