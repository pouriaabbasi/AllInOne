import { Component, OnInit, Input } from '@angular/core';
import { QuestionModel } from 'src/app/models/leitner.model';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  @Input()
  question: QuestionModel = new QuestionModel();

  constructor() { }

  ngOnInit() {
  }
}
