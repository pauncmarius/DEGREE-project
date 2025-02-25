import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { ImageComponent } from "../image/image.component";
import { CommonModule } from '@angular/common';
import { Photo } from '../../services/models/Photo';

@Component({
  selector: 'app-image-slider',
  standalone: true,
  imports: [CommonModule, ImageComponent],
  templateUrl: './image-slider.component.html',
  styleUrls: ['./image-slider.component.scss']
})

export class ImageSliderComponent implements OnChanges {
  @Input() images: Photo[] = new Array<Photo>();
  @Input() currentIndex: number = 0;
  @Output() currentIndexChange = new EventEmitter<number>();

  imagesToDisplay: Photo[] = [];
  offset: number = 7;

  constructor() {}
  ngOnChanges(changes: SimpleChanges): void {
    this.calculateImageToDisplay();
  }

  onImageClick(imageId: any) {
    this.currentIndexChange.emit(
      this.images.findIndex((img) => img.id === imageId)
    );
    console.log(`${this.currentIndex} slider`);
    this.calculateImageToDisplay();
  }

  private calculateImageToDisplay() {
    let partPhotos: Photo[] = [];
    if (this.currentIndex + this.offset > this.images.length) {
      this.images.slice(this.currentIndex).forEach((photo) => {
        partPhotos.push(photo);
      });
      this.images.slice(0, this.offset - partPhotos.length).forEach((image) => {
        partPhotos.push(image);
      });
    } else {
      partPhotos = this.images.slice(
        this.currentIndex,
        this.currentIndex + this.offset
      );
    }

    this.imagesToDisplay = partPhotos;
  }
}
