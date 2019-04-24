import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-load-photo',
  templateUrl: './load-photo.component.html'
})
export class LoadPhotoComponent {
  // public currentCount = 0;

  // public incrementCounter() {
  //   this.currentCount++;
  // }

  selectedFile: File

  constructor(private http: HttpClient){}

  onFileChanged(event) {
    this.selectedFile = event.target.files[0]
    console.log(event);
  }

  onUpload() {
    // upload code goes here
    const uploadData = new FormData();
  uploadData.append('myFile', this.selectedFile, this.selectedFile.name);
   this.http.post('https://localhost:44363/api/Profile/PersonLoadPhoto?login=login1&password=password1&path=D%3A%5C%5Cpost2.png', uploadData);
  //   .subscribe(...);

  // console.log(uploadData);
  }
}
