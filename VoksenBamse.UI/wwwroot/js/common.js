const sideNavId = 'side-nav';
const sideNavExpansionButtonId = 'side-nav-expansion-btn';
const sideNavExpandedClass = 'side-nav-expanded';
const sideNavCollapsedClass = 'side-nav-collapsed';
const sideNavExpandButtonIconId = 'side-nav-expansion-icon';
const sideNavExpandButtonIconExpandedClass = 'bi-arrows-expand-vertical';
const sideNavExpandButtonIconCollapsedClass = 'bi-arrows-collapse-vertical';
document.onreadystatechange = function (ev) {
    if (this.readyState == "interactive") {
        const sideNav = this.getElementById(`${sideNavId}`);
        const expansionButton = this.getElementById(`${sideNavExpansionButtonId}`);
        const expansionButtonIcon = this.getElementById(`${sideNavExpandButtonIconId}`);
        expansionButton.onclick = function (clkev) {
            var sideNavIsExpanded = sideNav.classList.contains(sideNavExpandedClass);
            if (sideNavIsExpanded) {
                sideNav.classList.remove(sideNavExpandedClass);
                sideNav.classList.add(sideNavCollapsedClass);
                expansionButtonIcon.classList.remove(sideNavExpandButtonIconExpandedClass);
                expansionButtonIcon.classList.add(sideNavExpandButtonIconCollapsedClass);
            }
            else {
                sideNav.classList.remove(sideNavCollapsedClass);
                sideNav.classList.add(sideNavExpandedClass);
                expansionButtonIcon.classList.remove(sideNavExpandButtonIconCollapsedClass);
                expansionButtonIcon.classList.add(sideNavExpandButtonIconExpandedClass);
            }
        };
    }
};
//# sourceMappingURL=common.js.map