import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-autocomplete-filter',
  templateUrl: './autocomplete-filter.component.html',
  styleUrls: ['./autocomplete-filter.component.css']
})
export class AutocompleteFilterComponent implements OnInit {

  // constructor() { }
  myControl = new FormControl();
  options: string[] = ['male', 'female'];
  filteredOptions: Observable<string[]>;

  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

}
