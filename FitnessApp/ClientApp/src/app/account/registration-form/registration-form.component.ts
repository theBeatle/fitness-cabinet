import { Component, OnInit } from '@angular/core';
import { NgForm} from '@angular/forms';
import { UserService } from "../../shared/services/user.service";

@Component({
  providers: [UserService],
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  constructor(private _userService: UserService) {
  }

  ngOnInit() {
  }

  registerUser(form: NgForm) {
    this._userService.register(form.value.email, form.value.password, form.value.firstName, form.value.lastName);
  }

}
