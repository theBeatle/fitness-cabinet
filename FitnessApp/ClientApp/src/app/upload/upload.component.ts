import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
// export class UploadComponent implements OnInit {

//   constructor() { }

//   ngOnInit() {
//   }

// }

export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  public response:boolean = true;
  // public myfile:string = "D:\\texteditor.png";

  public imagePath;
  imgURL: any;
  public message2: string;

  @Output() public onUploadFinished = new EventEmitter();
 
  constructor(private http: HttpClient) { }


  preview(files) {
    if (files.length === 0)
      return;
 
    var mimeType = files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.message2 = "Only images are supported.";
      return;
    }
 
    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result; 
    }
  }

 
  ngOnInit() {
  }
 
  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }

    var mimeType = files[0].type;
    if (mimeType.match(/image\/*/) == null) {
      this.message2 = "Only images are supported.";
      return;
    }

    var reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]); 
    reader.onload = (_event) => { 
      this.imgURL = reader.result; 
    }
 
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    // console.log(fileToUpload);
    // console.log(fileToUpload.name);
 
    this.http.post('https://localhost:44363/api/Upload/8', formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);

       
        }
      });

      this.progress=0;
  }
}
