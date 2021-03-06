import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  title: string = 'Workload Calculator';
  showAddTask: boolean = false;
  subscription: Subscription;

  constructor(private router: Router) {  }

  public isMobileLayout = false;
  ngOnInit() {
    window.onresize = () => this.isMobileLayout = window.innerWidth <= 991;
  }
  
   ngOnDestroy() {
     this.subscription.unsubscribe();
   }

  hasRoute(route: string) {
    return this.router.url === route;
  }
}
