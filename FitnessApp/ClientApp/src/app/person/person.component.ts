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
  // allPeople: Observable<Person[]>;
  user:Observable<Person>;
  userNameUpdate = null;
  message = null;

  constructor(private formbulider: FormBuilder, private wS: PersonService) { }

  // userName:string
  // firstName:string;
  // lastName :string;
  // email:string;
  // sexStatusId :number;
  // phoneNumber:string;  
  // isDeleted:boolean;
  // isBanned:boolean;
  

  ngOnInit() {
    this.personForm = this.formbulider.group({
      userName: ['', [Validators.required]],     
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required]],
      sexStatusId: ['', [Validators.required]],
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

  // loadAllWorkers() {
  //   this.allPeople = this.wS.getAllPeople();
  //   for (let index in this.allPeople) {
  //     console.log(index);
      
  //   }
  //   console.log( this.allPeople);
  // }

  onFormSubmit() {
    this.dataSaved = false;
    const worker = this.personForm.value;
    // this.CreateWorker(worker);
    this.loadUserByUserName()
    this.personForm.reset();
  }

  // CreateWorker(worker: Person) {
  //   if (this.workerIdUpdate == null) {
  //     this.wS.createWorker(worker).subscribe(
  //       () => {
  //         this.dataSaved = true;
  //         this.message = 'Record saved Successfully';
  //         this.loadAllWorkers();
  //         this.workerIdUpdate = null;
  //         this.personForm.reset();
  //       }
  //     );
  //   } else {
  //     worker.Id = this.workerIdUpdate;
  //     this.wS.updateWorker(worker).subscribe(() => {
  //       this.dataSaved = true;
  //       this.message = 'Record Updated Successfully';
  //       this.loadAllWorkers();
  //       this.workerIdUpdate = null;
  //       this.personForm.reset();
  //     });
  //   }
  // }

  // deleteWorker(workerId: string) {
  //   if (confirm('Are you sure you want to delete this ?')) {
  //     this.wS.deleteWorkerById(workerId).subscribe(() => {
  //       this.dataSaved = true;
  //       this.message = 'Record Deleted Succefully';
  //       this.loadAllWorkers();
  //       this.workerIdUpdate = null;
  //       this.personForm.reset();
  //     });
  //   }
  // }

  loadWorkerToEdit() {
    this.wS.getWorkerByUserName().subscribe( w => {
      this.message = null;
      this.dataSaved = false;
      // this.userNameUpdate = w.userName;

      this.personForm.controls.userName.setValue(w.userName);     
      this.personForm.controls.firstName.setValue(w.firstName);
      this.personForm.controls.lastName.setValue(w.lastName);
      this.personForm.controls.email.setValue(w.email);
      this.personForm.controls.sexStatusId.setValue(w.sexStatusId);
      this.personForm.controls.phoneNumber.setValue(w.phoneNumber);
      this.personForm.controls.isDeleted.setValue(w.isDeleted);
      this.personForm.controls.isBanned.setValue(w.isBanned);
    });
  }  
    // userName:string
  // firstName:string;
  // lastName :string;
  // email:string;
  // sexStatusId :number;
  // phoneNumber:string;  
  // isDeleted:boolean;
  // isBanned:boolean;

  resetForm() {
    this.personForm.reset();
    this.message = null;
    this.dataSaved = false;
  }

}
