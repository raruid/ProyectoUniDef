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
  UserDatosPerfilDto,
  EventoDatosPerfilDto,
  EventosServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './edit-evento-profile-dialog.component.html',
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
export class EditEventoProfileDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  user: UserDatosPerfilDto = new UserDatosPerfilDto();
  evento: EventoDatosPerfilDto = new EventoDatosPerfilDto();

  constructor(
    injector: Injector,
    public _userService: UserServiceProxy,
    public _eventoService: EventosServiceProxy,
    private _dialogRef: MatDialogRef<EditEventoProfileDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _idEvent: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._eventoService.getEventoPorId(this._idEvent).subscribe(result => {
      this.evento = result;
      });
  }

  save(): void {
    this.saving = true;

    this._eventoService
      .modificarDatosEvento(this.evento)
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
