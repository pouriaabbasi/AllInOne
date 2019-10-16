import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base/base.service';
import { Observable } from 'rxjs';
import { LeitnerBoxModel, LeitnerBoxStatisticsModel, AddQuestionModel, QuestionQueModel, ProcessQuestionModel } from '../models/leitner.model';

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

  public getBoxStatistics(boxId: number): Observable<LeitnerBoxStatisticsModel> {
    return super.get(`LeitnerBoxBox/GetBoxStatistics/${boxId}`);
  }

  public processBox(boxId: number): Observable<boolean> {
    return super.get(`LeitnerBoxQuestion/ProcessBox/${boxId}`);
  }

  public addQuestion(model: AddQuestionModel): Observable<AddQuestionModel> {
    return super.post('LeitnerBoxQuestion/AddQuestion', model);
  }

  public getQuestionQue(boxId: number): Observable<QuestionQueModel[]> {
    return super.get(`LeitnerBoxQuestion/GetQuestionQue/${boxId}`);
  }

  public processQuestion(model: ProcessQuestionModel): Observable<boolean> {
    return super.post('LeitnerBoxQuestion/ProcessQuestion', model);
  }
}
