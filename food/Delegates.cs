namespace food
{
    static class Delegates
    {
        internal delegate void addToListOfContentsDelegate(RecipeContent content);
        internal delegate void addContentsToDatabaseDelegate(Content content);
        internal delegate void closeAddContentPanelDelegate();
    }
}
