import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';

import { ProfileDetails } from '../models/profile.details.interface';
import { ConfigService } from '../../shared/utils/config.service';
import { BaseService } from '../../shared/services/base.service';
import { Observable } from 'rxjs/Rx';

// Add the RxJS Observable operators we need in this app.
import '../../rxjs-operators';

@Injectable()

export class ProfileService extends BaseService {

  baseUrl: string = '';

  constructor(private http: Http, private configService: ConfigService) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  getHomeDetails(): Observable<ProfileDetails> {
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let authToken = localStorage.getItem('auth_token');
    headers.append('Authorization', `Bearer ${authToken}`);
    
    return this.http.get(this.baseUrl + "/profile", { headers })
      .map(response => response.json())
      .catch(this.handleError);
  }
}