import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material'
import { BrowserModule } from '@angular/platform-browser';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  url = 'https://localhost:44363/Api';
  constructor(private http: HttpClient, private router: Router) { }
  userName: string;
  password: string;
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
  createLogin(login: Login): Observable<Login> {
    return this.http.post<Login>(this.url + '/Login/', login, this.httpOptions);
  }
  ngOnInit() {
  }
  //login(): void {
  //  if (this.username == 'user' && this.password == 'user') {
  //    this.router.navigate([""]);
  //  } else {
  //    alert("Invalid login/password");
  //  }
  //}

  login(): void {
  
    let dbapp;
      dbapp.append('username', this.userName);
    dbapp.append('password', this.password);
    dbapp.controller("AuthController", ['$async', function ($async, ) {
      getDatafromDatabase(); 
      function getDatafromDatabase() {
        $async.post('').success(function (data) {
          $async = "SELECT * from [AspNetUsers]";
          this.wS.getWorkerByUserName().subscribe(w => {
            this.message = null;
            this.dataSaved = false;
            this.personForm.controls.userName.setValue(w.userName);
        
            this.http.post('/api', dbapp).subscribe(
              error => {
                console.log(JSON.stringify(error.json()));
              }
            )
            this.http.post('/api',
              JSON.stringify({
                username: this.userName,
                password: this.password,
              })).subscribe
            error => {
              console.log(JSON.stringify(error.json()));
            }

            if (this.username === this.userName && this.password === this.password) {
              this.router.navigate([""]);
            }
            else {
              alert("Invalid login/password");
            }
          }
        }
      }
    }
  }
}
