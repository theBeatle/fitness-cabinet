import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { PersonService } from '../person.service';
import { Person } from '../person';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  dataSaved = false;
  personForm: any;  
  user:Observable<Person>;
  userNameUpdate = null;
  message = null;

  constructor(private formbulider: FormBuilder, private wS: PersonService) { }  

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

  loadUserByUserName(){
   
this.user = this.wS.getWorkerByUserName();
console.log( this.user);
  }  

  editUser(){
   
    this.user = this.wS.getWorkerByUserName();
    console.log( this.user);
      }

  onFormSubmit() {
    this.dataSaved = false;
    const user = this.personForm.value;
    
    console.log(user);
    this.wS.updateUser(user)
      .subscribe({
        next: res => { 
          console.log(res); 
          this.personForm.reset(); },
        error: err => { 
          console.log(err); }});   
  }
  
  loadWorkerToEdit() {
    this.wS.getWorkerByUserName().subscribe( w => {
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
}
