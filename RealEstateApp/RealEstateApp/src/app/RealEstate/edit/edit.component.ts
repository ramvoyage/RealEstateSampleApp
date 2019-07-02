import { Component, OnInit } from '@angular/core';
import { RealEstateService } from '../service.service';
import { Router, ActivatedRoute} from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  realEstateForm: FormGroup;
  value: any;
  id: any;

  constructor(public http: Http,
    private _router: Router,
    private route: ActivatedRoute,
    private formbuiler: FormBuilder,
    private _realEstateService: RealEstateService) { }

  ngOnInit() {
    this.initalizeRealEstateFrom();

    this._realEstateService.getById(this.route.snapshot.params.id).subscribe(
      data => {
        this.setRealEstateFrom(data);
      }
    );
  
  }

  setRealEstateFrom(data): void {

   if (data != undefined) {
     this.id = data.id;
      this.realEstateForm.setValue({
        area: data.area,
        price: data.price
      })
    }

  }

  initalizeRealEstateFrom(): void {

    this.realEstateForm = this.formbuiler.group({
      area: ['', [Validators.required, Validators.maxLength(100)]],
      price: ['', Validators.required]
    })

  }

  // convenience getter for easy access to form fields
  get realEstate() { return this.realEstateForm.controls; }

  //update releaestate 
  onupdateProperty(): void {
    this.realEstateForm.value.id = this.id;
    this._realEstateService.update(this.realEstateForm.value).subscribe(
      data => { console.log(JSON.parse(data)) }
    );
  }

  gotoList(): void {
    window.location.href = "http://localhost:50384/RealEstates";

  }
}
