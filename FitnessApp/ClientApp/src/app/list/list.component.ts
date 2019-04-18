import { Component } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { MatChipInputEvent } from '@angular/material';
export interface Fruit {
  name: string;
}
@Component({
  selector: 'app-list-component',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
 

export class ListComponent {
   title = 'app';
  visible = true;
  selectable = true;
  removable = true;
  addOnBlur = true;
  readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  fruits: Fruit[] = [
    { name: 'Lemon' },
    { name: 'Lime' },
    { name: 'Apple' },
  ];



  current_selected: string;

  onSelection(e, v) {
    this.current_selected = e.option.value;
  }

  add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    // Add our fruit
    if ((value || '').trim()) {
      this.fruits.push({name: value.trim() } );
    }

    // Reset the input value
    if (input) {
      input.value = '';
    }
  }

  remove(fruit: Fruit): void {
    const index = this.fruits.indexOf(fruit);

    if (index >= 0) {
      this.fruits.splice(index, 1);
    }
  }
}
