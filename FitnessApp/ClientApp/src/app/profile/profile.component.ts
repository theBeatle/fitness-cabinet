import { HttpEventType, HttpClient } from '@angular/common/http';
import { Component, Output, OnInit, EventEmitter, ElementRef } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { PersonService } from '../person.service';
import { Person } from '../person';
import { Element } from '@angular/compiler/src/render3/r3_ast';


@Component({
  selector: 'profile-data',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})

export class ProfileComponent implements OnInit {

  dataSaved = false;
  personForm: any;
  // allPeople: Observable<Person[]>;
  user: Observable<Person>;
  userNameUpdate = null;
  message = null;
  public progress: number;
  public response: boolean = true;
  public imagePath;
  imgURL: any;
  public message2: string;

  @Output() public onUploadFinished = new EventEmitter();

  constructor(private formbulider: FormBuilder, private wS: PersonService, private http: HttpClient, private elementRef: ElementRef) { }
  flag = false;
  ChangeBackground() {
    this.flag = !this.flag;
    if (this.flag == true) {
      this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = "#333333";
    }
    else {
      this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = "white";
    }
  }



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
    this.personForm = this.formbulider.group({
      userName: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required]],
      sexStatus: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      isDeleted: ['', [Validators.required]],
      isBanned: ['', [Validators.required]],

    });
    this.loadUserByUserName()
  }

  loadUserByUserName() {

    this.user = this.wS.getWorkerByUserName();
    console.log(this.user);
  }

  editUser() {

    this.user = this.wS.getWorkerByUserName();
    console.log(this.user);
  }

  onFormSubmit() {
    this.dataSaved = false;
    const user = this.personForm.value;

    console.log(user);
    this.wS.updateUser(user)
      .subscribe({
        next: res => {
          console.log(res);
          this.personForm.reset();
        },
        error: err => {
          console.log(err);
        }
      });
  }

  loadWorkerToEdit() {
    this.wS.getWorkerByUserName().subscribe(w => {
      this.message = null;
      this.dataSaved = false;

      this.personForm.controls.userName.setValue(w.userName);
      this.personForm.controls.firstName.setValue(w.firstName);
      this.personForm.controls.lastName.setValue(w.lastName);
      this.personForm.controls.email.setValue(w.email);
      this.personForm.controls.sexStatus.setValue(w.sexStatus);
      this.personForm.controls.phoneNumber.setValue(w.phoneNumber);
      this.personForm.controls.isDeleted.setValue(w.isDeleted);
      this.personForm.controls.isBanned.setValue(w.isBanned);
    });
  }

  resetForm() {
    this.personForm.reset();
    this.message = null;
    this.dataSaved = false;
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
