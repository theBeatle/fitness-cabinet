import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { MatDialog } from '@angular/material'
import { BrowserModule } from '@angular/platform-browser';
import { HttpHeaders } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { Login } from './login';
import { Observable } from 'rxjs';
import { URLSearchParams } from '@angular/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  url = 'https://localhost:44363/Api';
  constructor(private http: HttpClient,private router: Router) { }
  username: string; 
  password: string;
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
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
    let urlSearchParams = new URLSearchParams();
    urlSearchParams.append('username', this.username);
    urlSearchParams.append('password', this.password);
    
      this.http.post('/api', urlSearchParams).subscribe(
        data => {
          alert('ok');
        },
        error => {
          console.log(JSON.stringify(error.json()));
        }
      )
      this.http.post('/api',
        JSON.stringify({
          username: this.username,
          password: this.password,
        })).subscribe(
          data => {
            alert('ok');
          },
          error => {
            console.log(JSON.stringify(error.json()));
          }
      )
    
    if (this.username == this.username && this.password == this.password) {
      this.router.navigate([""]);
    }
    else {
      alert("Invalid login/password");
    }
  }

}
