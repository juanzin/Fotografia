import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';
import { PhotoRequestsService } from '../../../data/photo-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';

const MAX_NUMBER_PHOTOS: number = 11;

@Component({
  selector: 'app-phographer-manager',
  templateUrl: './phographer-manager.component.html',
  styleUrl: './phographer-manager.component.css'
})

export class PhographerManagerComponent implements OnInit, OnDestroy {
  
  private photographerId: number;
  public photographerInfo: any;
  public username: string;
  public photos: any[];
  public isOpenUploadModal: boolean;
  
  constructor(
    private photographerRequest: PhotographerRequestsService,
    private photosRequest: PhotoRequestsService,
    private dataStorage: DataStorageService) {
    this.photographerId = dataStorage.getPhotographerId();
    this.photographerInfo = {
      email: ""
    };
    this.username = "";
    this.photos = [];
    this.isOpenUploadModal = false;
  }

  loadPhotographerInfo() {
    this.username = this.photographerInfo.name + " " + this.photographerInfo.materno
    this.photographerInfo.phone = this.photographerInfo.phone;
    this.photographerInfo.location = this.photographerInfo.location;
  }

  loadPhotos(photos: any[]) {
    let numPhotos = photos.length;
    this.photos = [];
    for(let i = 0; i < numPhotos; i++) {
       this.photos.push({
        name: photos[i].title,
        url : photos[i].url_Photo 
      });
    }

    for(let i = numPhotos; i < MAX_NUMBER_PHOTOS; i++) {
      this.photos.push({
        name: "empty image",
        url: this.dataStorage.getEmptyImageUrl()
      });
    }

  }

  onOpenUploadPhoto() {
    console.log("opening upload photo modal");
    this.isOpenUploadModal = !this.isOpenUploadModal;
  }

  onCloseUploadModal() {
    this.isOpenUploadModal = false;
  }

  onUpdateInfo() {
    if(this.photographerInfo.email === ""
      || this.photographerInfo.phone === ""
      || this.photographerInfo.location === ""
      || this.photographerInfo.facebook === ""
      || this.photographerInfo.instagram === ""
      || this.photographerInfo.biography === ""
    ) {
      alert("toda la informacion es requerida");
    } else {
      let photographer = new FormData();
      photographer.append("email", this.photographerInfo.email);
      photographer.append("phone", this.photographerInfo.phone);
      photographer.append("location", this.photographerInfo.location);
      photographer.append("facebook", this.photographerInfo.facebook);
      photographer.append("instagram", this.photographerInfo.instagram);
      photographer.append("biography", this.photographerInfo.biography);
      this.photographerRequest.updatePhotographer(this.photographerId, photographer).subscribe({
        next: () => {
          alert("datos guardados exitosamente");
        },
        error: () => {
          alert("error al guardar");
        }
      });
    }

  }


  getPhotographerInfo() {
     this.photographerRequest.getPhotographerInfo(this.photographerId).subscribe({
      next: (data) => {
        if(data !== null) {
          this.photographerInfo = data;
          console.log("phographer info: ", this.photographerInfo);
          this.loadPhotographerInfo();
        } else {
          console.error("user not found");
        }
      },
      error: (err) => {
        console.error('Error loading photographer data', err);
      }
    });
  }

  getPhotos() {
    this.photosRequest.getPhotosByUser(this.photographerId).subscribe({
      next: (data) => {
        if(data === null) {
          data = [];
        }
        // this.photos = data;
        this.loadPhotos(data);
      },
      error: () => {
        console.error("error while retrieving photos");
      }
    });
  }

  ngOnInit(): void {
    this.getPhotographerInfo();
    this.getPhotos();
  }

  ngOnDestroy(): void {
    
  }
}
