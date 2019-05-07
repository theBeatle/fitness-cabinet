import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from './person';


@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url = 'https://localhost:44363/api';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };


  constructor(private http: HttpClient) { }

  getAllPeople(): Observable<Person[]> {
    return this.http.get<Person[]>(this.url + '/Profile');
  }

  getWorkerById(WorkerId: string): Observable<Person> {
    return this.http.get<Person>(this.url + '/Profile/' + WorkerId);
  }

  createWorker(worker: Person): Observable<Person> {
    return this.http.post<Person>(this.url + '/Profile/', worker, this.httpOptions);
  }

  updateWorker(worker: Person): Observable<Person> {
    return this.http.put<Person>(this.url + '/Profile/' + worker.Id, worker, this.httpOptions);
  }

  deleteWorkerById(workerId: string): Observable<number> {
    return this.http.delete<number>(this.url + '/Profile/' + workerId, this.httpOptions);
  }
}
