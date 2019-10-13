import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'src/app/_components/base/base.component';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router';
import { LeitnerService } from 'src/app/services/leitner.service';

@Component({
  selector: 'app-box-dashboard',
  templateUrl: './box-dashboard.component.html',
  styleUrls: ['./box-dashboard.component.css']
})
export class BoxDashboardComponent extends BaseComponent implements OnInit {

  boxName = '';

  constructor(
    protected toastr: ToastrService,
    private route: ActivatedRoute,
    private leitnerService: LeitnerService
  ) {
    super(toastr);
  }

  ngOnInit() {
    this.fetchStatistics();
  }

  private fetchStatistics() {
    this.route.paramMap.subscribe(params => {
      const boxId = params.get('id');
      this.leitnerService.getBox(Number(boxId)).subscribe(result => {
        this.boxName = result.name;
      });
    });
  }
}
