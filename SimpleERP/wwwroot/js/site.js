(() => {
    const shell = document.querySelector(".app-shell");
    const sidebar = document.getElementById("appSidebar");
    const toggle = document.getElementById("sidebarToggle");
    const backdrop = document.getElementById("sidebarBackdrop");

    if (!shell || !sidebar || !toggle || !backdrop) {
        return;
    }

    const mobileLayout = window.matchMedia("(max-width: 767.98px)");

    function setMobileOpen(isOpen) {
        shell.classList.toggle("is-sidebar-open", isOpen);
        sidebar.classList.toggle("is-open", isOpen);
        backdrop.hidden = !isOpen;
        sidebar.inert = !isOpen;

        toggle.setAttribute("aria-expanded", String(isOpen));
        toggle.setAttribute("aria-label", isOpen ? "Fechar menu" : "Abrir menu");
    }

    function setDesktopOpen(isOpen) {
        shell.classList.toggle("is-sidebar-collapsed", !isOpen);
        sidebar.inert = !isOpen;

        toggle.setAttribute("aria-expanded", String(isOpen));
        toggle.setAttribute(
            "aria-label",
            isOpen ? "Recolher menu" : "Expandir menu"
        );
    }

    function syncLayout() {
        if (mobileLayout.matches) {
            shell.classList.remove("is-sidebar-collapsed");
            setMobileOpen(false);
        } else {
            shell.classList.remove("is-sidebar-open");
            sidebar.classList.remove("is-open");
            backdrop.hidden = true;
            setDesktopOpen(true);
        }
    }

    toggle.addEventListener("click", () => {
        if (mobileLayout.matches) {
            setMobileOpen(!sidebar.classList.contains("is-open"));
        } else {
            setDesktopOpen(shell.classList.contains("is-sidebar-collapsed"));
        }
    });

    backdrop.addEventListener("click", () => setMobileOpen(false));

    sidebar.querySelectorAll("a").forEach((link) => {
        link.addEventListener("click", () => {
            if (mobileLayout.matches) {
                setMobileOpen(false);
            }
        });
    });

    document.addEventListener("keydown", (event) => {
        if (
            event.key === "Escape" &&
            mobileLayout.matches &&
            sidebar.classList.contains("is-open")
        ) {
            setMobileOpen(false);
            toggle.focus();
        }
    });

    mobileLayout.addEventListener("change", syncLayout);
    syncLayout();
})();

const themeToggle = document.getElementById("themeToggle");
const sunIcon = document.getElementById("themeIconSun");
const moonIcon = document.getElementById("themeIconMoon");
const savedTheme = localStorage.getItem("simpleerp-theme");

if (savedTheme === "dark") {
    document.documentElement.setAttribute("data-theme", "dark");
}

function updateThemeButton() {
    const isDark = document.documentElement.getAttribute("data-theme") === "dark";

    sunIcon.hidden = isDark;
    moonIcon.hidden = !isDark;
    themeToggle.setAttribute("aria-pressed", String(isDark));

    const label = isDark ? "Ativar modo claro" : "Ativar modo escuro";
    themeToggle.setAttribute("aria-label", label);
    themeToggle.setAttribute("title", label);
}

if (themeToggle && sunIcon && moonIcon) {
    updateThemeButton();

    themeToggle.addEventListener("click", () => {
        const isDark = document.documentElement.getAttribute("data-theme") !== "dark";

        if (isDark) {
            document.documentElement.setAttribute("data-theme", "dark");
            localStorage.setItem("simpleerp-theme", "dark");
        } else {
            document.documentElement.removeAttribute("data-theme");
            localStorage.setItem("simpleerp-theme", "light");
        }

        updateThemeButton();
    });
}