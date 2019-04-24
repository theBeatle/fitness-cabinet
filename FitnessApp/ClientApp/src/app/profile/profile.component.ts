import { Component } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'profile-data',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  template: `

<mat-card   class="example-card">
  <mat-form-field class="example-full-width">
    <input matInput placeholder="Name">
  </mat-form-field>
  <br />
  <mat-form-field class="example-full-width">
    <textarea matInput placeholder="Leave a comment"></textarea>
  </mat-form-field>
  <br/>
  <mat-button-toggle-group name="fontStyle" aria-label="Font Style">
    <mat-button-toggle (click)="onClickMe()">Click me!</mat-button-toggle>
  </mat-button-toggle-group>
    {{clickMessage}}
    < /mat-card> `
})


export class ProfileComponent {
  clickMessage = '';

  onClickMe() {
    this.clickMessage = 'You are my hero!';
  }
}

