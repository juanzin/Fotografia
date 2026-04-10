import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';
import { PhotoRequestsService } from '../../../data/photo-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';
import { CategoryRequestsService } from '../../../data/category-requests.service';

@Component({
  selector: 'app-upload-photo',
  templateUrl: './upload-photo.component.html',
  styleUrl: './upload-photo.component.css'
})
export class UploadPhotoComponent implements OnInit, OnDestroy{
  @Output() close = new EventEmitter<void>();

  private photographerId: number;
  public selectedFile: any;
  public title: string;
  public description: string;
  public categories: any[];
  public selectedcategory: any;

  constructor(
    private photographerRequest: PhotographerRequestsService,
    private photosRequest: PhotoRequestsService,
    private categoryRequests: CategoryRequestsService,
    private dataStorage: DataStorageService) {
    this.photographerId = dataStorage.getPhotographerId();
    
    this.selectedFile = {
      name: ""
    };
    this.title = "";
    this.description = "";
    this.categories = [];
    this.selectedcategory = {};
  }

  onUploadPhoto() {

    // let photo = {
    //   Title: this.title,
    //   Description: this.description,
    //   Category_Id: this.selectedcategory.id
    // };

    // let photo = {
    //   file: this.selectedFile,
    //   title: this.title,
    //   photographerId: this.photographerId,
    //   categoryId: this.selectedcategory.id,
    //   description: this.description,
    // };

    let photo = new FormData();
    photo.append("file", this.selectedFile);
    photo.append("title", this.title);
    photo.append("photographerId", this.photographerId.toString());
    photo.append("categoryId", this.selectedcategory.id);
    photo.append("description", this.description);

    this.photosRequest.savePhoto(photo).subscribe({
      next: () => {
        alert("saved photo");
        console.log("stored successfully");
      },
      error: (error) => {
        console.error("Error while saving....");
      }
    })
  }

  onFileSelected(event: any): void {
    let file = event.target.files[0];

    if (file) {
      this.selectedFile = file;
      console.log('Selected file:', file);
    }

    if (file && file.type.startsWith('image/')) {
      // valid image
      console.log("this is a image", this.selectedFile);
    } else {
      alert('Only images are allowed');
    }
  }
  
  getCategories() {
    this.categoryRequests.getCategories().subscribe({
      next: (data) => {
        if(data.length > 0) {
          this.categories = data;
          this.selectedcategory = this.categories[0]; 
        }
      },
      error: (err) => {
        console.error('Error loading categories', err);
      }
    });
  }

  closeModal(): void {
    this.close.emit();
  }

  ngOnInit(): void {
    this.getCategories();
  }

  ngOnDestroy(): void {
    
  }

}
