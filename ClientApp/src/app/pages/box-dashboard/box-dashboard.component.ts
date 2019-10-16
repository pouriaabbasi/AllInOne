import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { LeitnerService } from 'src/app/services/leitner.service';
import { Chart } from 'chart.js';
import { LeitnerBoxStatisticsModel, QuestionModel } from 'src/app/models/leitner.model';
import * as $ from 'jquery';


@Component({
  selector: 'app-box-dashboard',
  templateUrl: './box-dashboard.component.html',
  styleUrls: ['./box-dashboard.component.css']
})
export class BoxDashboardComponent extends BaseComponent implements OnInit {
  @ViewChild('revenueLineChart', null) chart: ElementRef;


  constructor(
    protected toastr: ToastrService,
    private route: ActivatedRoute,
    private leitnerService: LeitnerService
  ) {
    super(toastr);
  }

  statistics = new LeitnerBoxStatisticsModel();
  boxId = '0';
  question = new QuestionModel();
  questions: QuestionModel[] = [];

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const boxId = params.get('id');
      this.fetchStatistics(boxId);
    });
  }

  private fetchStatistics(boxId: string) {
    this.leitnerService.getBoxStatistics(Number(boxId)).subscribe(result => {
      this.statistics = result;
      this.createChart(result.labels, result.counts);
    });
  }

  private createChart(labels: string[], counts: number[]) {
    const ctx = this.chart.nativeElement.getContext('2d');
    const revenueLineChart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels,
        datasets: [{
          // label: 'stages',
          data: counts,
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(255, 159, 64, 0.2)',
            'rgba(255, 205, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(54, 162, 235, 0.2)'
          ],
          borderColor: [
            'rgb(255, 99, 132)',
            'rgb(255, 159, 64)',
            'rgb(255, 205, 86)',
            'rgb(75, 192, 192)',
            'rgb(54, 162, 235)'
          ],
          borderWidth: 2
        }]
      },
      options: {
        legend: {
          display: false
        },
      }
    });
  }

  public processBox() {
    const boxId = this.route.snapshot.paramMap.get('id');
    this.leitnerService.processBox(Number(boxId))
      .subscribe(result => {
        if (result) {
          super.showSuccess('Process Compeleted', 'Box questions process successfuly');
          this.fetchStatistics(boxId);
        }
      });
  }

  public AddQuestion() {
    const boxId = this.route.snapshot.paramMap.get('id');
    console.log(boxId);
    this.question.boxId = Number(boxId);
    this.leitnerService.addQuestion(this.question)
      .subscribe(result => {
        if (result) {
          this.fetchStatistics(boxId);
          this.question = new QuestionModel();
          super.showSuccess('Add Question', 'Question add successfuly');
        }
      });
  }
}
