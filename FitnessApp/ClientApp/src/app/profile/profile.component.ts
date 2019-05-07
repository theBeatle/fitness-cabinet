import { MatSidenavModule } from '@angular/material/sidenav';
import { getContext } from '@angular/core/src/render3/discovery_utils';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'profile-data',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})

export class ProfileComponent {
  Name = 'Maks';
  SureName = 'Iskandirov';
  SexStatus = 'Men';
  clickMessage2 = 'asd';
  flag = true;
  PushInfo() {
    this.Name = this.clickMessage2;
    this.SureName = this.clickMessage2;
    this.SexStatus = this.clickMessage2;


  }
  ChangeBackground() {
    this.flag = !this.flag;
    var up = document.getElementsByTagName('body')[1];
    var down = document.getElementsByTagName('body')[0];
    if (this.flag == false) {
      up.style.backgroundColor = "#333333";
      down.style.backgroundColor = "#333333";
    }
    else {
      up.style.backgroundColor = "white";
      down.style.backgroundColor = "white";
    }
  }


  public progress: number;
  public message: string;
  public response: boolean = true;
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

    this.http.post('https://localhost:44363/api/Upload', formData, { reportProgress: true, observe: 'events' })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.onUploadFinished.emit(event.body);


        }
      });

    this.progress = 0;
  }
}
