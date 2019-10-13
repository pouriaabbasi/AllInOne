import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Observable } from 'rxjs';
import { LeitnerBoxModel } from '../models/leitner.model';

@Injectable({
  providedIn: 'root'
})
export class LeitnerService extends BaseService {

  constructor(
    protected http: HttpClient
  ) {
    super(http);
  }

  public addBox(boxName: string): Observable<LeitnerBoxModel> {
    return super.post('LeitnerBoxBox/AddBox', { name: boxName });
  }

  public getBoxes(): Observable<LeitnerBoxModel[]> {
    return super.get('LeitnerBoxBox/GetAllBox');
  }

  public removeBox(boxId: number): Observable<boolean> {
    return super.delete(`LeitnerBoxBox/DeleteBox/${boxId}`);
  }

  public getBox(boxId: number): Observable<LeitnerBoxModel> {
    return super.get(`LeitnerBoxBox/GetBox/${boxId}`);
  }
}
