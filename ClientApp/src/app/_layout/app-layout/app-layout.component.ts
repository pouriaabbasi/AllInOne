import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import * as AdminLte from 'src/assets/dist/js/adminlte.min.js';

@Component({
  selector: 'app-app-layout',
  templateUrl: './app-layout.component.html',
  styleUrls: ['./app-layout.component.css']
})
export class AppLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  // tslint:disable-next-line: use-life-cycle-interface
  ngAfterViewInit() {
    $('[data-widget="treeview"]').each(function () {
      AdminLte.Treeview._jQueryInterface.call($(this), 'init');
    });
  }

}
