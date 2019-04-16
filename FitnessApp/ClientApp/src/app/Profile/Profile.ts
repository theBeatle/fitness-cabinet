import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-profile-data',
  templateUrl: './Profile.html'
})
export class ProfileDataComponent {
  public profile: Profile[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Profile[]>(baseUrl + 'api/SampleData/Profiles').subscribe(result => {
      this.profile = result;
    }, error => console.error(error));
  }
}

interface Profile {
}
