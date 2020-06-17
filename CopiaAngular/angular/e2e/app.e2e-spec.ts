import { UniDefTemplatePage } from './app.po';

describe('UniDef App', function() {
  let page: UniDefTemplatePage;

  beforeEach(() => {
    page = new UniDefTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
