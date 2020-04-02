let drag_node = null;

document.querySelectorAll(".node").forEach(nodes);
document.querySelectorAll(".column").forEach(columns);

function columns(column) {

    column.addEventListener("dragover", dragover_column);
    column.addEventListener("drop", drop_column);
}

function dragover_column(event) {
    event.preventDefault();
}

function drop_column(event) {
    event.stopPropagation();
    console.log(drag_node);
    this.insertAdjacentElement('beforeend', drag_node);
}

function nodes(node) {

    node.addEventListener("dragstart", dragstart_node);
    node.addEventListener("dragend", dragend_node);
    node.addEventListener("dragenter", dragenter_node);
    node.addEventListener("dragover", dragover_node);
    node.addEventListener("dragleave", dragleave_node);
    node.addEventListener("drop", drop_node);
}

function dragstart_node(event) {
    drag_node = this;
    this.classList.add("dragElement");

    event.stopPropagation();
}

function dragend_node(event) {
    drag_node = null;
    this.classList.remove("dragElement");

    document.querySelectorAll(".node").forEach(x => x.classList.remove("under"));
}

function dragenter_node(event) {
    if (this == drag_node) {
        return;
    }
    this.classList.add("under");
}

function dragover_node(event) {
    event.preventDefault();
    if (this == drag_node) {
        return;
    }
}

function dragleave_node(event) {
    if (this == drag_node) {
        return;
    }
    this.classList.remove("under");
}

function drop_node(event) {
    event.stopPropagation();

    if (this == drag_node) {
        return;
    }

    if (this.parentElement == drag_node.parentElement) {
        let node = Array.from(this.parentElement.querySelectorAll(".node"));
        let i = node.indexOf(this);
        let y = node.indexOf(drag_node);

        if (i < y) {
            this.insertAdjacentElement('beforebegin', drag_node);
        } else {
            this.insertAdjacentElement('afterend', drag_node);
        }
    } else {
        this.insertAdjacentElement('beforebegin', drag_node);
    }
}