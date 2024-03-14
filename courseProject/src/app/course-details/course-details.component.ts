import { Component, Input } from '@angular/core';
import { Course } from '../entities/course.model';
import { Category } from '../entities/category.model';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../services/category.service';
import { LearningWayIconPipe } from '../learning-way-icon.pipe';
import { ActivatedRoute } from '@angular/router';
import { CourseService } from '../services/courses.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-course-details',
  standalone: true,
  imports: [CommonModule, LearningWayIconPipe, MatFormFieldModule, MatInputModule],
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css']
})
export class CourseDetailsComponent {
  public course!: Course;
  public category!: Category;
  public isInComingWeek = false;

  constructor(private route: ActivatedRoute, private categoryService: CategoryService, private courseService: CourseService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.courseService.getCourseById(id).subscribe({
        next: (res) => {
          this.course = res;
          this.categoryService.getCategoryById(this.course.categoryId).subscribe(
            {
              next: (res) => {
                this.category = res;
              },
              error: (err) => {
                console.error(err);
              }
            });
          this.checkComingWeek();
        },
        error: (err) => {
          console.error(err);
        }
      });
    });
  }

  checkComingWeek() {
    const today = new Date();
    const courseStartDate = new Date(this.course.start);
    const nextWeek = new Date(today.getTime() + 7 * 24 * 60 * 60 * 1000);
    this.isInComingWeek = courseStartDate >= today && courseStartDate <= nextWeek;
  }
}
