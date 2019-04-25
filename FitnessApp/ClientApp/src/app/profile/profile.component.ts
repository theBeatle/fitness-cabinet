import { Component } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';

@Component({
  selector: 'profile-data',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  template: `
  <mat-card  class="example-card">
   <img src="http://synergymentor.ru/upload/iblock/43d/43d43cb8844432a2addf89f8be7200f7.jpg" style="width:200px;height:400" class="md-card-image" alt="image caption"/>
  <mat-form-field class="example-full-width">
    <input matInput  placeholder="Name" value="{{Name}}">
  </mat-form-field>
  <br />
  <mat-form-field class="example-full-width">
    <input matInput  placeholder="Sure Name" value="{{SureName}}">
  </mat-form-field>
  <br/>
<mat-form-field>
  <input matInput [matDatepicker]="picker" placeholder="Date of birth">
  <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
  <mat-datepicker #picker></mat-datepicker>
</mat-form-field>
  <br/>
  <mat-form-field class="example-full-width">
    <input matInput  placeholder="sex status" value="{{SexStatus}}">
  </mat-form-field>
  <br/>
  <mat-button-toggle-group name="fontStyle" aria-label="Font Style">
    <mat-button-toggle color="primary" (click)="onClickMe()">Click me!</mat-button-toggle>
  </mat-button-toggle-group>
  <br/>
  <mat-slide-toggle>Dark mode</mat-slide-toggle>
  </mat-card> `
    
})


export class ProfileComponent {
  Name = 'Maks';
  SureName = 'Iskandirov';
  SexStatus = 'Men';
  clickMessage2 = 'asd';

  onClickMe() {
    this.Name = this.clickMessage2;
    this.SureName = this.clickMessage2;
    this.SexStatus = this.clickMessage2;
  }
}

