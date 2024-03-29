import { Component, Injector, Optional, Inject, OnInit } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {
  UserServiceProxy,
  RoleDto,
  UserDatosPerfilDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './edit-user-profile-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class EditUserProfileDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  user: UserDatosPerfilDto = new UserDatosPerfilDto();

  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    private _dialogRef: MatDialogRef<EditUserProfileDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._userService.getDatosUsuarioLogado().subscribe(result => {
      this.user = result;
      });
  }

  save(): void {
    this.saving = true;

    this._userService
      .updateDatosPerfilUsuarioLogado(this.user)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
}
