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
  allPeople: Observable<Person[]>;
  workerIdUpdate = null;
  message = null;

  constructor(private formbulider: FormBuilder, private wS: PersonService) { }

  ngOnInit() {
    this.personForm = this.formbulider.group({
      Login: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      FirstName: ['', [Validators.required]],
      LastName: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      SexStatusId: ['', [Validators.required]],
      Phone: ['', [Validators.required]],
      IsDeleted: ['', [Validators.required]],     
      IsBanned: ['', [Validators.required]],
    
    });
     this.loadAllWorkers();
  }

  loadAllWorkers() {
    this.allPeople = this.wS.getAllPeople();
    for (let index in this.allPeople) {
      console.log(index);
      
    }
    console.log( this.allPeople);
  }

  onFormSubmit() {
    this.dataSaved = false;
    const worker = this.personForm.value;
    this.CreateWorker(worker);
    this.personForm.reset();
  }

  CreateWorker(worker: Person) {
    if (this.workerIdUpdate == null) {
      this.wS.createWorker(worker).subscribe(
        () => {
          this.dataSaved = true;
          this.message = 'Record saved Successfully';
          this.loadAllWorkers();
          this.workerIdUpdate = null;
          this.personForm.reset();
        }
      );
    } else {
      worker.Id = this.workerIdUpdate;
      this.wS.updateWorker(worker).subscribe(() => {
        this.dataSaved = true;
        this.message = 'Record Updated Successfully';
        this.loadAllWorkers();
        this.workerIdUpdate = null;
        this.personForm.reset();
      });
    }
  }

  deleteWorker(workerId: string) {
    if (confirm('Are you sure you want to delete this ?')) {
      this.wS.deleteWorkerById(workerId).subscribe(() => {
        this.dataSaved = true;
        this.message = 'Record Deleted Succefully';
        this.loadAllWorkers();
        this.workerIdUpdate = null;
        this.personForm.reset();
      });
    }
  }

  loadWorkerToEdit(workerId: string) {
    this.wS.getWorkerById(workerId).subscribe( w => {
      this.message = null;
      this.dataSaved = false;
      this.workerIdUpdate = w.Id;

      this.personForm.controls.Login.setValue(w.Login);
      this.personForm.controls.Password.setValue(w.Password);
      this.personForm.controls.FirstName.setValue(w.FirstName);
      this.personForm.controls.LastName.setValue(w.LastName);
      this.personForm.controls.Email.setValue(w.Email);
      this.personForm.controls.SexStatusId.setValue(w.SexStatusId);
      this.personForm.controls.Phone.setValue(w.Phone);
      this.personForm.controls.IsDeleted.setValue(w.IsDeleted);
      this.personForm.controls.IsBanned.setValue(w.IsBanned);
    });
  }

  //   Login:string;
    // Password :string;
    // FirstName:string;
    // LastName :string;
    // Email:string;
    // SexStatusId :number;
    // Phone:string;  
    // IsDeleted:boolean;
    // IsBanned:boolean;

  resetForm() {
    this.personForm.reset();
    this.message = null;
    this.dataSaved = false;
  }

}
