import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from './person';


@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url = 'https://localhost:44363/api/';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };


  constructor(private http: HttpClient) { }  

  getWorkerByUserName(): Observable<Person> {
    let authToken = localStorage.getItem('auth_token');

    this.httpOptions.headers.append('Content-Type', 'application/json');
    this.httpOptions.headers.append('Authorization', `Bearer ${authToken}`);

    return this.http.get<Person>(this.url + "Upload/", this.httpOptions);
  }  

  updateUser(worker: Person): Observable<Person> {
    
    let authToken = localStorage.getItem('auth_token');

    this.httpOptions.headers.append('Content-Type', 'application/json');
    this.httpOptions.headers.append('Authorization', `Bearer ${authToken}`);

    return this.http.put<Person>(this.url + "Upload/", worker, this.httpOptions);
  }  

  getSexStatuses(): Observable<string[]> {
    return this.http.get<string[]>(this.url + "Profile/");
  } 
}
