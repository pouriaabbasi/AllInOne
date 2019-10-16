import { Component, OnInit, Input, Renderer2, Inject } from '@angular/core';
import { QuestionModel } from 'src/app/models/leitner.model';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-answer-question',
  templateUrl: './answer-question.component.html',
  styleUrls: ['./answer-question.component.css']
})
export class AnswerQuestionComponent implements OnInit {

  @Input()
  questions: QuestionModel[];

  constructor(
    private renderer2: Renderer2,
    @Inject(DOCUMENT) private document: Document
  ) { }

  ngOnInit() {
    const script = this.renderer2.createElement('script');
    script.type = `application/javascript`;
    script.text = `
    console.log('fire fire')
    var card = document.querySelector('.card');
    card.addEventListener('click', function () {
        console.log('fire');
        card.classList.toggle('is-flipped');
    });
        `;

    this.renderer2.appendChild(this.document.body, script);
  }

}
