import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-image',
  standalone: true,
  imports: [],
  templateUrl: './image.component.html',
  styleUrl: './image.component.scss'
})

export class ImageComponent implements OnInit {
  @Input() src: string = '';
  @Input() id: number = 0;
  @Output() imageClick = new EventEmitter<number>();
  constructor() {}

  onClick() {
    this.imageClick.emit(this.id);
  }
  ngOnInit(): void {}
}
