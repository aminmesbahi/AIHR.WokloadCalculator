import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';
import { CourseService } from '../../services/course.service';
import { Course } from '../../Course';
import { CalculationRequest } from '../../CalculationRequest';
import { MatSelectionListChange } from '@angular/material/list';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css'],
})
export class CoursesComponent implements OnInit {
  courses: Course[] = [];
  selectedCourses: Course[] = [];
  selectedDays:number=0;
  suggestedDailyStudyHours:string=null;
  calculationRequest: CalculationRequest={courseIds:[],startDate:new Date(),endDate:new Date()};
  environmentUrl = '';
  private apiUrl = '';

  constructor(private courseService: CourseService, private http: HttpClient) {
    this.environmentUrl = environment.baseUrl;
    this.apiUrl=this.environmentUrl+'v1/WorkloadCalculator/CalculateWorkload';
  }

  ngOnInit(): void {
    this.courseService.getCourses().subscribe((courses) => (this.courses = courses));
  }
 
  dateRangeChange(dateRangeStart: HTMLInputElement, dateRangeEnd: HTMLInputElement) {
    const oneDay = 1000 * 60 * 60 * 24;
    const sDate=new Date(dateRangeStart.value);
    const eDate=new Date(dateRangeEnd.value);

    const start = Date.UTC(eDate.getFullYear(), eDate.getMonth(), eDate.getDate());
    const end = Date.UTC(sDate.getFullYear(), sDate.getMonth(), sDate.getDate());
  
    this.selectedDays= (start - end) / oneDay;

    this.calculationRequest.startDate=new Date(dateRangeStart.value);
    this.calculationRequest.endDate=new Date(dateRangeEnd.value);
  }
  checkButton():boolean{
    if(this.selectedDays>0 && this.selectedCourses.length>0){
      return false;
    }
    else{
      return true;
    }
  }
  calculate() {
    const headers = { 'content-type': 'application/json'};
    this.calculationRequest.courseIds=this.courses.filter(x=>x.isSelected).map((course) => {
      return course.id
    });
    const body=JSON.stringify(this.calculationRequest);
    this.http.post(this.apiUrl, body,{'headers':headers}).subscribe((data:any)=>{
      this.suggestedDailyStudyHours=data.suggestedDailyStudyHours;
  
  })
  
  }
  onCourseSelectionChange(event:MatSelectionListChange, course) {
    if(course.isSelected)
    {
      course.isSelected=false;
    }
    else{
      course.isSelected=true;
    }
    this.selectedCourses=this.courses.filter(x=>x.isSelected); 
  }

  total() {
    return this.courses.reduce((total, course) => total + course.duration, 0);
  }
  
  selected(){
    let count = 0; 
   this.courses.forEach(c => {
          if(c.isSelected == true)
          count += 1;
      });
      return count;
  }

  selectedHours(){
    let sum = 0; 
   this.courses.forEach(c => {
          if(c.isSelected == true)
          sum += c.duration;
      });
      return sum;
  }

  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl(),
  });

}
