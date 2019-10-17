import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { LeitnerService } from 'src/app/services/leitner.service';
import { Chart } from 'chart.js';
import { LeitnerBoxStatisticsModel } from 'src/app/models/leitner.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { QuestionComponent } from '../question/question.component';
import { AnswerQuestionComponent } from '../answer-question/answer-question.component';


@Component({
  selector: 'app-box-dashboard',
  templateUrl: './box-dashboard.component.html',
  styleUrls: ['./box-dashboard.component.css']
})
export class BoxDashboardComponent extends BaseComponent implements OnInit {
  @ViewChild('revenueLineChart', null) chart: ElementRef;

  myChart: Chart;


  constructor(
    protected toastr: ToastrService,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private leitnerService: LeitnerService
  ) {
    super(toastr);
  }

  statistics = new LeitnerBoxStatisticsModel();
  boxId = '0';

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
    if (this.myChart) {
      this.myChart.destroy();
    }
    const ctx = this.chart.nativeElement.getContext('2d');
    this.myChart = new Chart(ctx, {
      type: 'doughnut',
      data: {
        labels,
        datasets: [{
          // label: 'stages',
          data: counts,
          backgroundColor: [
            'rgb(178,34,34)',
            'rgb(255,99,71)',
            'rgb(255,215,0)',
            'rgb(64,224,208)',
            'rgb(0,255,127)'
          ],
          borderColor: [
            'rgb(139,0,0)',
            'rgb(255,69,0)',
            'rgb(255,165,0)',
            'rgb(70,130,180)',
            'rgb(34,139,34)'
          ],
          borderWidth: 2
        }]
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

  public openQuestion() {
    const boxId = this.route.snapshot.paramMap.get('id');
    const modalRef = this.modalService.open(QuestionComponent, {
      centered: true
    });
    modalRef.componentInstance.boxId = boxId;
    modalRef.result.then(result => {
      if (result) {
        this.fetchStatistics(boxId);
      }
    }, () => { });
  }

  public openAnswerQuestion() {
    const boxId = this.route.snapshot.paramMap.get('id');
    const modalRef = this.modalService.open(AnswerQuestionComponent, {
      centered: true
    });
    modalRef.componentInstance.boxId = boxId;
    modalRef.result.then(result => {
      if (result) {
        this.fetchStatistics(boxId);
      }
    }, () => { });
  }
}
