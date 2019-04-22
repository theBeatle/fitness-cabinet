import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from './person';


@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url = 'http://localhost:44363/api/Profile';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };


  constructor(private http: HttpClient) { }

  getAllPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.url + '/GetPeople');
  }
}
