import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [CommonModule,MatToolbarModule, MatButtonModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {
  public isLecturer!:boolean;
  public isConnected!:boolean;

  constructor(private router: Router){}
  ngOnInit() {
    this.isConnected=sessionStorage.getItem('userDetails')!=null;
    this.isLecturer = sessionStorage.getItem('isLecturer') === 'true';
  }

  login()
  {
    this.router.navigate(['/login']);
  }

  register()
  {
    this.router.navigate(['/register']);
  }

  logout()
  {
    sessionStorage.removeItem('userDetails');
    sessionStorage.removeItem('isLecturer');
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate(['/home']);
    });
  }

  allCourses()
  {
    this.router.navigate(['/allCourses']);
  }

  addCourse()
  {
    this.router.navigate(['/addCourse']);
  }
}