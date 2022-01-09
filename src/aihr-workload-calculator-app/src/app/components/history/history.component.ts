import {Component, ViewChild, AfterViewInit, OnInit} from '@angular/core';
import { HistoryService } from '../../services/history.service';
import { HistoryItem } from '../../HistoryItem';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';


@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements AfterViewInit  {
  displayedColumns: string[] = ['id','startDate', 'endDate', 'suggestedHours', 'courses', 'created'];
  historyItems: HistoryItem[] = [];
  dataSource=new MatTableDataSource();// MatTableDataSource<HistoryItem>;
  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;


  constructor(private historyService: HistoryService) { 
    this.historyService.getHistory().subscribe(data => this.dataSource.data = data);
  }

  ngAfterViewInit(): void {     
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;    
  }

}
