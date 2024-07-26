import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  userId: string | null = null;

  constructor(private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('userId');
  }

  navigateToAddChat() {
    if (this.userId) {
      this.router.navigateByUrl(`${this.userId}/add-chat`);
    }
  }
}
