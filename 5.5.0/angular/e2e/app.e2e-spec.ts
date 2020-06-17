import { FOOCTemplatePage } from './app.po';

describe('FOOC App', function() {
  let page: FOOCTemplatePage;

  beforeEach(() => {
    page = new FOOCTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
