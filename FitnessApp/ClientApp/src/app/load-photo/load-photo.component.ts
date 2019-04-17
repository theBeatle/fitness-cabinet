import { Component } from '@angular/core';

@Component({
  selector: 'app-load-photo',
  templateUrl: './load-photo.component.html'
})
export class LoadPhotoComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
