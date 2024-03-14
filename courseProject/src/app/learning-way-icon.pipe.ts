import { Pipe, PipeTransform } from '@angular/core';
import { LearningWay } from './entities/course.model';

@Pipe({
  name: 'learningWayIcon',
  standalone: true
})
export class LearningWayIconPipe implements PipeTransform {

  transform(value: LearningWay): string {
    if (value === LearningWay.frontal) {
      return 'frontal-icon'; // Assume 'frontal-icon' is the icon class for frontal mode
    } else if (value === LearningWay.Zoom) {
      return 'zoom-icon'; // Assume 'zoom-icon' is the icon class for zoom mode
    } else {
      return 'default-icon'; // Default icon class if learning mode is not recognized
    }
  }
}
