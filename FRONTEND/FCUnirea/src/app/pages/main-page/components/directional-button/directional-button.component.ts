import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-directional-button',
  standalone: true,
  imports: [],
  templateUrl: './directional-button.component.html',
  styleUrl: './directional-button.component.scss'
})
export class DirectionalButtonComponent {
  @Input() IncrementBy: number = 0;
  @Input() index: number = 0;
  @Output() changeIndex = new EventEmitter<number>();

  Increment() {
    this.changeIndex.emit(this.index + this.IncrementBy);
  }
}
