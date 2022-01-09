import { Injectable, Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Course } from '../Course';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  environmentUrl = '';
  private apiUrl = '';

  constructor(private http: HttpClient) {
    this.environmentUrl = environment.baseUrl;
    this.apiUrl=this.environmentUrl+'v1/WorkloadCalculator/GetCourseList';
  }

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.apiUrl);
  }
}
