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
    //   Login:string;
    // Password :string;
    // FirstName:string;
    // LastName :string;
    // Email:string;
    // SexStatusId :number;
    // Phone:string;  
    // IsDeleted:boolean;
    // IsBanned:boolean;
    });
    this.loadAllWorkers();
  }

  loadAllWorkers() {
    this.allPeople = this.wS.getAllPeople();
  }

}
