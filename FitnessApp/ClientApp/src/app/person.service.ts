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
    return this.http.get<Person>(this.url + "Upload/");
  }  

  updateUser(worker: Person): Observable<Person> {
    return this.http.put<Person>(this.url + "Upload/", worker, this.httpOptions);
  }  

  getSexStatuses(): Observable<string[]> {
    return this.http.get<string[]>(this.url + "Profile/");
  } 
}
