import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HistoryItem } from '../HistoryItem';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class HistoryService {
  environmentUrl = '';
  private apiUrl = '';

  constructor(private http: HttpClient) {
    this.environmentUrl = environment.baseUrl;
    this.apiUrl=this.environmentUrl+'v1/WorkloadCalculator/GetWorkloadCalculationsHistory';
  }

  getHistory(): Observable<HistoryItem[]> {
    return this.http.get<HistoryItem[]>(this.apiUrl);
  }
}
