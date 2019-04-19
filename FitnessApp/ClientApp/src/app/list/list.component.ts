import { Component } from '@angular/core';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
 
export interface Fruit {
  name: string;
  checked: boolean;
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
    { name: 'Lemon', checked: false },
    { name: 'Lime', checked: false },
    { name: 'Apple', checked: false },
  ];

  chipsFruits = new Array();

  onSelection(e, v) {
    if (e.option.selected) {
      this.chipsFruits.push(e.option.value.name);
    }
    else {
      const index = this.chipsFruits.indexOf(e.option.value.name);
      if (index >= 0) {
        this.chipsFruits.splice(index, 1);
      }
    }
  }

  remove(fruit): void {
    const index = this.chipsFruits.indexOf(fruit);
    if (index >= 0) {
      for (let i = 0; i < this.fruits.length; ++i) {
        if (this.fruits[i].name === fruit) {
          this.fruits[i].checked = false;
        }
      }
      this.chipsFruits.splice(index, 1);
    }
  }
}
