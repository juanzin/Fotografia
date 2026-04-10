import { Component, EventEmitter, Output } from '@angular/core';
import { PhotoRequestsService } from '../../../data/photo-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';

@Component({
  selector: 'app-delete-photo',
  templateUrl: './delete-photo.component.html',
  styleUrl: './delete-photo.component.css'
})
export class DeletePhotoComponent {
  @Output() close = new EventEmitter<string>();


  private photographerId: number;

  constructor(private photosRequest: PhotoRequestsService, private dataStorage: DataStorageService) {
    this.photographerId = dataStorage.getPhotographerId();
  }

  onDeletePhoto() {
    this.close.emit("si");
  }

  closeModal(): void {
    this.close.emit("no");
  }

}
