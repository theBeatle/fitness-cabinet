import { Component } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'profile-data',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})


export class ProfileComponent {
  showFiller = false;
  title = 'app';
}

